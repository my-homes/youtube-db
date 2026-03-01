#! /usr/bin/env bash
set -uvx
set -e
cd "$(dirname "$0")"
cwd=`pwd`
ts=`date "+%Y.%m%d.%H%M.%S"`

mkdir -p all
dir-multi.exe /p/@youtube-1080p | tee all/1080p.m3u
truncate -s -1 all/1080p.m3u
jq --raw-input --slurp 'split("\n")' all/1080p.m3u | tee all/1080p-full-path.json
./.r.mk-1080p-list | tee all/1080p-list.json
