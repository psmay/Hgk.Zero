#!/bin/bash

GITHUB_REPO_USER=psmay
GITHUB_REPO=Hgk.Zero
GITHUB_REPO_URL_WITH_TOKEN="https://$GITHUB_REPO_USER:$GITHUB_DOC_GENERATION_TOKEN@github.com/$GITHUB_REPO_USER/$GITHUB_REPO.git"

START="`pwd`"
DOCFX_JSON_FILE="$START/Documentation.docfx/docfx.json"
TMPDIR="`mktemp -d`"
INSTALLS="$TMPDIR/installs"

# Install docfx.console
mkdir -p "$INSTALLS" &&
cd "$INSTALLS" &&
nuget install docfx.console -ExcludeVersion &&
# Why the next two lines? See https://github.com/dotnet/docfx/issues/3389
nuget install SQLitePCLRaw.core -ExcludeVersion &&
cp SQLitePCLRaw.core/lib/net45/SQLitePCLRaw.core.dll docfx.console/tools/ &&

# Build documentation to $TMPDIR/outputs
cd "$START" &&
DOCFX="mono $INSTALLS/docfx.console/tools/docfx.exe" &&
$DOCFX metadata $DOCFX_JSON -o "$TMPDIR/outputs" &&
$DOCFX build $DOCFX_JSON -o "$TMPDIR/outputs" &&

# Get repo for gh-pages
cd "$TMPDIR" &&
git clone "$GITHUB_REPO_URL_WITH_TOKEN" -b gh-pages pages_repo -q &&
cd pages_repo &&
git config user.email travis_ci_build@invalid.invalid &&
git config user.name travis_ci_build &&
cd .. &&

# Clobber current site dir with new one
rm -rf pages_repo/docfx &&
cp -a outputs/_site pages_repo/docfx &&

# Commit new version and push
cd pages_repo &&
git add -A &&
git commit -m "Update from CI #$TRAVIS_BUILD_NUMBER, branch $TRAVIS_BRANCH" -q &&
git push origin gh-pages -q

ACTUAL_EXIT_CODE=$?

# Hide the evidence
rm -rf "$TMPDIR"

exit $ACTUAL_EXIT_CODE
