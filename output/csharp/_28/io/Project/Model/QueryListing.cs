using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _28.io.Project.Model {

  [DataContract(Name = "QueryListing")]
  public class QueryListing {
    /* The list of public queries. It is always present when listing all queries or public queries */
    [DataMember(Name = "public")]
    public List<Query> _public { get; set; }

    /* The list of public queries. It is always present when listing all queries or private queries */
    [DataMember(Name = "private")]
    public List<Query> _private { get; set; }

    }
  }
