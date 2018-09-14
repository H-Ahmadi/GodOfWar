﻿using System.Collections.Generic;
using FluentAssertions;
using ProductManagement.Domain.Model.Constraints;
using ProductManagement.Domain.Model.Product;
using Xunit;

namespace ProductManagement.Domain.Tests.Unit
{
    public class ProductTests
    {
        private readonly ProductBuilder _productBuilder;
        public ProductTests()
        {
            _productBuilder = new ProductBuilder();
        }

        [Fact]
        public void Constructor_should_create_product()
        {
            var productname = "Soccer ball";
            var product = _productBuilder.WithRootProduct(productname).Build();
            product.Name.Should().Be(productname);
            product.Parent.Should().Be(null);
        }

        
    }


    internal class ProductBuilder
    {
        private string Name { get; set; }
        private Product Parent { get; set; }
        private List<PropertyConstraint> PropertyConstraints { get; set; }

        public Product Build()
        {
            return new Product(Name, Parent, PropertyConstraints);
        }

        public ProductBuilder WithRootProduct(string productname)
        {
            Name = productname;
            Parent = null;
            return this;
        }

        public ProductBuilder WithRootProductNoProperty(string productname)
        {
            Name = productname;
            Parent = null;
            PropertyConstraints = null;
            return this;
        }

        public ProductBuilder WithActualProductParentNoProperty(string productname)
        {
            Name = productname;
            Parent = new ActualProduct("",null,null);
            PropertyConstraints = null;
            return this;
        }
    }
}
