# .NET MAUI Blazor Hybrid - Custom Authentication Sample

This is a demonstration project supporting a [blog posting](https://mitchelsellers.com/blog/article/net-maui-blazor-hybrid-custom-authentication-implementation) discussing custom authentication in .NET MAUI Blazor Hybrid applications.

## Disclaimer

This project is currently built upon the Preview 14 version of .NET MAUI and all items included in here are subject to change, and could no-longer function in later preview releases or final releases of MAUI/Blazor.  Additionally, this is a sample implementation, and might need further rigorous testing implementations to 100% validate security, so please use at your discretion. 

## Solution Goal

The goal of this example is to showcase how you can implement custom authentication within an .NET MAUI Blazor Hybrid application in a manner where you can authenticate a user via an alternative means, other than Azure AD or OAuth and work using the built in authentication controls & processes for your MAUI application.

## Installation Assumptions

To utilize this sample project you must be running Visual Studio 2022 Preview 2.1 (17.2.0 Preview 2.1), or possibly later, with the .NET MAUI features installed.  

I will update this as future releases occur.

## Repository structure

For ease of use, the project initially contains 2 commits.

1. Initial source code from project creation using the Visual Studio Templates
2. A secondary commit with all custom authentication bits included.  This includes securing of all sample pages, and the addition of a new login screen.