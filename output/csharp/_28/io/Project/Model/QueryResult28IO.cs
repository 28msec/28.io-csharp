using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _28.io.Project.Model {

  [DataContract(Name = "QueryResult28IO")]
  public class QueryResult28IO {
    /* The default content-type. All serialized items that do not contains a "content_type" field have this content-type */
    [DataMember(Name = "defaultContentType")]
    public string defaultContentType { get; set; }

    /* The serialized query result items */
    [DataMember(Name = "items")]
    public List<Item28IO> items { get; set; }

    /*  */
    [DataMember(Name = "count")]
    public int count { get; set; }

    }
  }
