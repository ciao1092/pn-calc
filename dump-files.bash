#!/bin/bash

# Directory to scan for .cs files (change it to your desired directory)
directory="."  # Current directory

# Loop over all .cs files in the directory
for file in "$directory"/*.cs; do
  # Check if it's a regular file
  if [ -f "$file" ]; then
    # Print file name
    echo "# File: \"$file\""
    # Print file content
    cat "$file"
    echo  # Add a blank line between files
  fi
done
