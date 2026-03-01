#! /usr/bin/env bash
set -uvx
set -e
cd "$(dirname "$0")"
cwd=`pwd`
ts=`date "+%Y.%m%d.%H%M.%S"`

mkdir -p all
wingen.exe
.r.mk-all-json @merge
./mk-all-json.exe | tee all/all.json
