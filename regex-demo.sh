#! /usr/bin/env bash
set -uvx
set -e
cd "$(dirname "$0")"
cwd=`pwd`
ts=`date "+%Y.%m%d.%H%M.%S"`

line="[INFO] User 'john_doe' logged in from IP 192.168.1.100 at 2025-03-01."
regex="User '([[:alnum:]_]+)' logged in from IP ([[:digit:].]+) at ([[:digit:]-]+)"

if [[ $line =~ $regex ]]; then
    echo "Match found!"
    echo "Username: ${BASH_REMATCH[1]}"
    echo "IP Address: ${BASH_REMATCH[2]}"
    echo "Date: ${BASH_REMATCH[3]}"
else
    echo "No match found."
fi
