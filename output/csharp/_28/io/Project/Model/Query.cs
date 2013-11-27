using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _28.io.Project.Model {

  [DataContract(Name = "Query")]
  public class Query {
    /* The query path. (e.g.: "/public/query.jq") */
    [DataMember(Name = "href")]
    public string href { get; set; }

    /* The date and time the query was last modified */
    [DataMember(Name = "lastModified")]
    public DateTime lastModified { get; set; }

    }
  }
