// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace NuGet.Protocol.Catalog
{
    public class CatalogClientFacts
    {
        public class GetIndexAsync
        {
            [Fact]
            public async Task WorksWithNuGetOrgSnapshot()
            {
                // Arrange
                using (var httpClient = new HttpClient(new TestDataHttpMessageHandler()))
                {
                    var client = new CatalogClient(httpClient, new NullLogger<CatalogClient>());

                    // Act
                    var actual = await client.GetIndexAsync(TestData.CatalogIndexUrl);

                    // Assert
                    Assert.NotNull(actual);
                    Assert.NotEqual(default(DateTimeOffset), actual.CommitTimestamp);
                    Assert.NotEqual(0, actual.Count);
                    Assert.NotEmpty(actual.Items);
                }
            }
        }

        public class GetPageAsync
        {
            [Fact]
            public async Task WorksWithNuGetOrgSnapshot()
            {
                // Arrange
                using (var httpClient = new HttpClient(new TestDataHttpMessageHandler()))
                {
                    var client = new CatalogClient(httpClient, new NullLogger<CatalogClient>());

                    // Act
                    var actual = await client.GetPageAsync(TestData.CatalogPageUrl);

                    // Assert
                    Assert.NotNull(actual);
                    Assert.NotEqual(default(DateTimeOffset), actual.CommitTimestamp);
                    Assert.NotEqual(0, actual.Count);
                    Assert.NotEmpty(actual.Items);
                }
            }
        }

        public class GetPackageDeleteLeafAsync
        {
            [Fact]
            public async Task WorksWithNuGetOrgSnapshot()
            {
                // Arrange
                using (var httpClient = new HttpClient(new TestDataHttpMessageHandler()))
                {
                    var client = new CatalogClient(httpClient, new NullLogger<CatalogClient>());

                    // Act
                    var actual = await client.GetPackageDeleteLeafAsync(TestData.PackageDeleteCatalogLeafUrl);

                    // Assert
                    Assert.NotNull(actual);
                }
            }
        }

        public class GetPackageDetailsLeafAsync
        {
            [Fact]
            public async Task WorksWithNuGetOrgSnapshot()
            {
                // Arrange
                using (var httpClient = new HttpClient(new TestDataHttpMessageHandler()))
                {
                    var client = new CatalogClient(httpClient, new NullLogger<CatalogClient>());

                    // Act
                    var actual = await client.GetPackageDetailsLeafAsync(TestData.PackageDetailsCatalogLeafUrl);

                    // Assert
                    Assert.NotNull(actual);
                }
            }
        }

        public class GetLeafAsync
        {
            [Fact]
            public async Task WorksWithNuGetOrgPackageDeleteSnapshot()
            {
                // Arrange
                using (var httpClient = new HttpClient(new TestDataHttpMessageHandler()))
                {
                    var client = new CatalogClient(httpClient, new NullLogger<CatalogClient>());

                    // Act
                    var actual = await client.GetLeafAsync(TestData.PackageDeleteCatalogLeafUrl);

                    // Assert
                    Assert.NotNull(actual);
                }
            }

            [Fact]
            public async Task WorksWithNuGetOrgPackageDetailsSnapshot()
            {
                // Arrange
                using (var httpClient = new HttpClient(new TestDataHttpMessageHandler()))
                {
                    var client = new CatalogClient(httpClient, new NullLogger<CatalogClient>());

                    // Act
                    var actual = await client.GetLeafAsync(TestData.PackageDetailsCatalogLeafUrl);

                    // Assert
                    Assert.NotNull(actual);
                }
            }
        }
    }
}
