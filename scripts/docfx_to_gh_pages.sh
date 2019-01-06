#!/bin/bash

GITHUB_REPO_USER=psmay
GITHUB_REPO=Hgk.Zero
GITHUB_REPO_URL_WITH_TOKEN="https://$GITHUB_REPO_USER:$GITHUB_DOC_GENERATION_TOKEN@github.com/$GITHUB_REPO_USER/$GITHUB_REPO.git"

START="`pwd`"
DOCFX_PROJECT_DIR="$START/Documentation.docfx"
TMPDIR="`mktemp -d`"
INSTALLS="$TMPDIR/installs"

# Create and go to our local installs dir
mkdir -p "$INSTALLS" &&
cd "$INSTALLS" &&

# Install mono and nuget in a rather ugly fashion
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
sudo apt-get install apt-transport-https
echo "deb https://download.mono-project.com/repo/ubuntu stable-xenial main" | sudo tee /etc/apt/sources.list.d/mono-official-stable.list
sudo apt-get update
sudo apt-get install ca-certificates-mono mono-runtime msbuild nuget &&

# Install docfx.console
nuget install docfx.console -ExcludeVersion &&
DOCFX="mono $INSTALLS/docfx.console/tools/docfx.exe" &&
# Why the next two lines? See https://github.com/dotnet/docfx/issues/3389
nuget install SQLitePCLRaw.core -ExcludeVersion &&
cp SQLitePCLRaw.core/lib/net45/SQLitePCLRaw.core.dll docfx.console/tools/ &&


# Build documentation to $TMPDIR/outputs
cd "$DOCFX_PROJECT_DIR" &&
$DOCFX metadata docfx.json -o "$TMPDIR/outputs" &&
$DOCFX build docfx.json -o "$TMPDIR/outputs" &&

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
