#!/bin/bash

#
# SHOULD BUILD IMAGE BEFORE
# docker build -t lambdareadytorun:3.0 .
#

rm -f $(pwd)/bootstrap
rm -f $(pwd)/package.zip
docker run -it --rm -v $(pwd):/app lambdareadytorun:3.0
#cp bin/Release/netcoreapp3.0/linux-x64/publish/netcore3-readytorun-efcore bootstrap
#chmod 777 bootstrap
#zip package.zip bootstrap
cp bin/Release/netcoreapp3.0/linux-x64/publish/netcore3-readytorun-efcore bin/Release/netcoreapp3.0/linux-x64/publish/bootstrap
chmod 777 bin/Release/netcoreapp3.0/linux-x64/publish/*
zip -j package.zip bin/Release/netcoreapp3.0/linux-x64/publish/*
aws s3 cp package.zip s3://ifewtemp