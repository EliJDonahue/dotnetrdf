﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VDS.RDF.Configuration;
using VDS.RDF.Query.PropertyFunctions;

namespace VDS.RDF.Test.Configuration
{
    [TestClass]
    public class LoadObjectTests
    {
        [TestMethod]
        public void ConfigurationLoadObjectPropertyFunctionFactory()
        {
            String graph = ConfigLookupTests.Prefixes + @"
_:a a dnr:SparqlPropertyFunctionFactory ;
  dnr:type """ + typeof(MockPropertyFunctionFactory).AssemblyQualifiedName + @""" .";

            Graph g = new Graph();
            g.LoadFromString(graph);

            IPropertyFunctionFactory factory = ConfigurationLoader.LoadObject(g, g.GetBlankNode("a")) as IPropertyFunctionFactory;
            Assert.IsNotNull(factory);
            Assert.AreEqual(typeof(MockPropertyFunctionFactory), factory.GetType());
        }

        [TestMethod]
        public void ConfigurationLoadObjectTripleCollection1()
        {
            String graph = ConfigLookupTests.Prefixes + @"
_:a a dnr:TripleCollection ;
  dnr:type ""VDS.RDF.TreeIndexedTripleCollection"" .";

            Graph g = new Graph();
            g.LoadFromString(graph);

            BaseTripleCollection collection = ConfigurationLoader.LoadObject(g, g.GetBlankNode("a")) as BaseTripleCollection;
            Assert.IsNotNull(collection);
            Assert.AreEqual(typeof(TreeIndexedTripleCollection), collection.GetType());
        }

        [TestMethod]
        public void ConfigurationLoadObjectTripleCollection2()
        {
            String graph = ConfigLookupTests.Prefixes + @"
_:a a dnr:TripleCollection ;
  dnr:type ""VDS.RDF.ThreadSafeTripleCollection"" ;
  dnr:usingTripleCollection _:b .
_:b a dnr:TripleCollection ;
  dnr:type ""VDS.RDF.TreeIndexedTripleCollection"" .";

            Graph g = new Graph();
            g.LoadFromString(graph);

            BaseTripleCollection collection = ConfigurationLoader.LoadObject(g, g.GetBlankNode("a")) as BaseTripleCollection;
            Assert.IsNotNull(collection);
            Assert.AreEqual(typeof(ThreadSafeTripleCollection), collection.GetType());
        }

        [TestMethod]
        public void ConfigurationLoadObjectGraphCollection1()
        {
            String graph = ConfigLookupTests.Prefixes + @"
_:a a dnr:GraphCollection ;
  dnr:type ""VDS.RDF.GraphCollection"" .";

            Graph g = new Graph();
            g.LoadFromString(graph);

            BaseGraphCollection collection = ConfigurationLoader.LoadObject(g, g.GetBlankNode("a")) as BaseGraphCollection;
            Assert.IsNotNull(collection);
            Assert.AreEqual(typeof(GraphCollection), collection.GetType());
        }

        [TestMethod]
        public void ConfigurationLoadObjectGraphCollection2()
        {
            String graph = ConfigLookupTests.Prefixes + @"
_:a a dnr:GraphCollection ;
  dnr:type ""VDS.RDF.ThreadSafeGraphCollection"" ;
  dnr:usingGraphCollection _:b .
_:b a dnr:GraphCollection ;
  dnr:type ""VDS.RDF.GraphCollection"" .";

            Graph g = new Graph();
            g.LoadFromString(graph);

            BaseGraphCollection collection = ConfigurationLoader.LoadObject(g, g.GetBlankNode("a")) as BaseGraphCollection;
            Assert.IsNotNull(collection);
            Assert.AreEqual(typeof(ThreadSafeGraphCollection), collection.GetType());
        }

        [TestMethod]
        public void ConfigurationLoadObjectGraphCollection3()
        {
            String graph = ConfigLookupTests.Prefixes + @"
_:a a dnr:GraphCollection ;
  dnr:type ""VDS.RDF.DiskDemandGraphCollection"" ;
  dnr:usingGraphCollection _:b .
_:b a dnr:GraphCollection ;
  dnr:type ""VDS.RDF.GraphCollection"" .";

            Graph g = new Graph();
            g.LoadFromString(graph);

            BaseGraphCollection collection = ConfigurationLoader.LoadObject(g, g.GetBlankNode("a")) as BaseGraphCollection;
            Assert.IsNotNull(collection);
            Assert.AreEqual(typeof(DiskDemandGraphCollection), collection.GetType());
        }

        [TestMethod]
        public void ConfigurationLoadObjectGraphCollection4()
        {
            String graph = ConfigLookupTests.Prefixes + @"
_:a a dnr:GraphCollection ;
  dnr:type ""VDS.RDF.WebDemandGraphCollection"" ;
  dnr:usingGraphCollection _:b .
_:b a dnr:GraphCollection ;
  dnr:type ""VDS.RDF.GraphCollection"" .";

            Graph g = new Graph();
            g.LoadFromString(graph);

            BaseGraphCollection collection = ConfigurationLoader.LoadObject(g, g.GetBlankNode("a")) as BaseGraphCollection;
            Assert.IsNotNull(collection);
            Assert.AreEqual(typeof(WebDemandGraphCollection), collection.GetType());
        }

        [TestMethod]
        public void ConfigurationLoadObjectGraphCollection5()
        {
            String graph = ConfigLookupTests.Prefixes + @"
_:a a dnr:GraphCollection ;
  dnr:type ""VDS.RDF.WebDemandGraphCollection"" ;
  dnr:usingGraphCollection _:b .
_:b a dnr:GraphCollection ;
  dnr:type ""VDS.RDF.ThreadSafeGraphCollection"" ;
  dnr:usingGraphCollection _:c .
_:c a dnr:GraphCollection ;
  dnr:type ""VDS.RDF.GraphCollection"" .";

            Graph g = new Graph();
            g.LoadFromString(graph);

            BaseGraphCollection collection = ConfigurationLoader.LoadObject(g, g.GetBlankNode("a")) as BaseGraphCollection;
            Assert.IsNotNull(collection);
            Assert.AreEqual(typeof(WebDemandGraphCollection), collection.GetType());
        }
    }

    class MockPropertyFunctionFactory
        : IPropertyFunctionFactory
    {
        public bool IsPropertyFunction(Uri u)
        {
            throw new NotImplementedException();
        }

        public bool TryCreatePropertyFunction(PropertyFunctionInfo info, out RDF.Query.Patterns.IPropertyFunctionPattern function)
        {
            throw new NotImplementedException();
        }
    }
}
