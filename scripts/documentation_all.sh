#!/bin/bash

. scripts/functions.bash

require_variable TOP
require_variable SCRIPTS
default_variable DOCFX_PROJECT_DIR docfx_project
export DOCFX_PROJECT_DIR="$(realpath "$DOCFX_PROJECT_DIR")"
export INSTALLS="`mktemp -d`"

ensure_docfx_exe_defined () {
	# DOCFX_EXE should be set to the full path of docfx.exe. If it isn't set,
	# this will install docfx under the temporary install dir and set the
	# variable.
	if [ "-$DOCFX_EXE-" = "--" ]; then
		eecho 'DOCFX_EXE not defined; installing local copy of docfx'
		export DOCFX_EXE=`(
			cd "$INSTALLS" &&
			bash "$SCRIPTS/install_docfx_console_here.sh"
		)`
	fi
}

install_mono &&
ensure_docfx_exe_defined &&
bash "$SCRIPTS/build_documentation.sh" &&
bash "$SCRIPTS/push_documentation.sh"
