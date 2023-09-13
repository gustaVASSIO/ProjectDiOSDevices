*** Settings ***
Library    XML
Library    RequestsLibrary
Library    String
Library    OperatingSystem
Library    Telnet

*** Keywords ***
Create session on api
    Create Session    alias=API    url=https://localhost:7248/api

Mount a device object
    ${name}    Generate Random String    1
    ${description}    Generate Random String    1
    ${foto_file}    Get Binary File    C:/Users/ANG7CA/Documents/20230824_143550_mfnr.jpg
    ${document_file}    Get Binary File    C:/Users/ANG7CA/Documents/Model_Release_extern_und_intern_C-CGC-IC_BZ_en.pdf
    
    ${body}    Create Dictionary
    ...    name=${name} 
    ...    description=${description} 
    # ...    foto=${foto_file} 
    # ...    document=${document_file} 
       
    Set Test Variable    ${body}
Send a request to api
    ${Header}     Create Dictionary    accept=multipart/form-data

    ${response}    POST On Session
    ...    alias=API
    ...    url=/Devices
    ...    headers=${Header}
    ...    files=${body}

Verify if response status is
    [Arguments]    ${status_verify}
    IF    ${status_verify} == 201
        Pass Execution    Post device with success
    ELSE
        Fail    Error in post device
    END
    
    