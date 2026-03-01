#! /usr/bin/env bash
set -uvx
set -e
cd "$(dirname "$0")"
cwd=`pwd`
ts=`date "+%Y.%m%d.%H%M.%S"`

mkdir -p all
wingen.exe
# rm -f ./mk-all-json.???
.r.mk-all-json @merge
./mk-all-json.exe | tee all/all.json
