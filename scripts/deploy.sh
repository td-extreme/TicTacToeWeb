
#!/bin/bash

set -e

connection=$1

ssh $connection './deploy.sh'
exit 0