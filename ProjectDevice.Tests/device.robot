*** Settings ***
Resource    device.resource
Test Setup    Create session on api

*** Test Cases ***
Test01 - Create a device with success
    Mount a device object
    Send a request to api
    Verify if response status is ${200}