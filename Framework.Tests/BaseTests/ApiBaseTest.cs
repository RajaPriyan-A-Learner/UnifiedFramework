using Framework.API;
using Framework.API.Wrapper;
using Framework.Core.Interfaces;
using NUnit.Framework;
using System;

namespace Framework.Tests
{
    public class ApiBaseTest
    {
        protected IApiClient Api { get; private set; }

        [SetUp]
        public void SetUp()
        {
            // 1. Get Base URL from Environment or Default
            string baseUrl = Environment.GetEnvironmentVariable("API_BASE_URL") ?? "https://reqres.in";

            // 2. Composition Root: Initialize the RestSharp implementation
            Api = new RestSharpClient(baseUrl);

            // Note: You can add logic here to inject Bearer Tokens 
            // or API Keys into the client if your API requires auth.
        }

        [TearDown]
        public void TearDown()
        {
            // Clean up resources if necessary
            Api = null;
        }
    }
}