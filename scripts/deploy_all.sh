#!/bin/bash

. scripts/functions.bash

shopt -s globstar
for i in Hgk.Zero.*/**/*-$VERSION_SUFFIX.nupkg; do 
	eecho "Attempting to push $i"
	dotnet nuget push $i --api-key $NUGET_API_KEY --source $NUGET_SOURCE || exit
	eecho "Push seems to have succeeded for $i"
done

