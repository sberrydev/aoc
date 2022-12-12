#!/bin/env bash

pad_number=$(printf "%02d" $1)
number=$(printf "%1d" $1)
output_file="../../AdventOfCode2022/Day${pad_number}/ActualInput.txt"

curl --insecure -X GET -H "Cookie: session=${ADVENT_OF_CODE_COOKIE}" -H "Host: 172.31.61.174" "https://adventofcode.com/2022/day/${number}/input" -o "$output_file"