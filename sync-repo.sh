# This bash script uses git to synchronize changes between the local and remote GitHub repository.
# Usage: ./sync-repo.sh

# steps:
# 1. stage all changes
# 2. commit changes with message 'Updated'
# 3. pull changes from remote repository on branch 'main'
# 4. push changes to remote repository on branch 'main'.
# 5. check if the push was successful


#!/bin/bash

# Stage all changes
git add .

# Commit changes with a message "Committing changes"
git commit -m "Committing changes"

# Pull changes from the remote repository on branch 'main'
git pull origin main

# Push changes to the remote repository on branch 'main'
git push origin main

# Check if the push was successful
if [ $? -eq 0 ]; then
    echo "Push was successful."
else
    echo "Push failed. Please check for errors."
    exit 1
fi


# Echo a message that the synchronization is complete
echo "Synchronization complete."
exit 0




