#!/bin/bash

# Quick Start Script for PokemonGraphQL API

echo "🚀 Starting PokemonGraphQL API..."
echo ""

# Check if .NET is installed
if ! command -v dotnet &> /dev/null
then
    echo "❌ .NET SDK is not installed. Please install .NET 9.0 or later."
    echo "   Download from: https://dotnet.microsoft.com/download"
    exit 1
fi

# Check .NET version
echo "✅ .NET SDK version:"
dotnet --version
echo ""

# Restore packages
echo "📦 Restoring NuGet packages..."
dotnet restore
echo ""

# Build the project
echo "🔨 Building the project..."
dotnet build
if [ $? -ne 0 ]; then
    echo "❌ Build failed. Please check the errors above."
    exit 1
fi
echo ""

# Run the application
echo "🎮 Starting the GraphQL API server..."
echo "   GraphQL Endpoint: http://localhost:5000/graphql"
echo ""
echo "📝 Example queries available in EXAMPLE_QUERIES.md"
echo "📖 Testing guide available in TESTING.md"
echo ""
echo "Press Ctrl+C to stop the server"
echo ""
dotnet run --urls "http://localhost:5000"
