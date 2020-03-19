# gRPC .NET Core Demo
Demo of gRPC server and client in .NET Core.

# About gPRC

gRPC is a language agnostic, high-performance Remote Procedure Call (RPC) framework.

The main benefits of gRPC are:

Modern, high-performance, lightweight RPC framework.
Contract-first API development, using Protocol Buffers by default, allowing for language agnostic implementations.
Tooling available for many languages to generate strongly-typed servers and clients.
Supports client, server, and bi-directional streaming calls.
Reduced network usage with Protobuf binary serialization.
These benefits make gRPC ideal for:

Lightweight microservices where efficiency is critical.
Polyglot systems where multiple languages are required for development.
Point-to-point real-time services that need to handle streaming requests or responses.

# Getting Started

1. Clone Repo.
2. Open Solution within Visual Studio.
3. Run and follow instructions within the client terminal. (Both client and server are configured as a multiple startup option).

# Solution Structure

This solution contains two projects, a gRPC client and a gRPC Server. Each project contains the .proto files to generate the underlying language specific templates for the gRPC connection to run. Those templates are generated on compilation due to the inclusion of the grpc.tools nuget package. Specific properties on the .proto files govern the expectations around the generated files. The gRPC routes are mapped into dotnet core within startup.cs. The solution is configured to run both the server and client when run simultaneously within Visual Studio (2019).