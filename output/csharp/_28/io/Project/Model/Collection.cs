using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _28.io.Project.Model {

  [DataContract(Name = "Collection")]
  public class Collection {
    /* The name of the collection */
    [DataMember(Name = "name")]
    public string name { get; set; }

    /* The local name of the collection */
    [DataMember(Name = "nameLoc")]
    public string nameLoc { get; set; }

    /* The declared type of the items in the collection */
    [DataMember(Name = "type")]
    public string type { get; set; }

    /* The number of items in the collection */
    [DataMember(Name = "countItems")]
    public int countItems { get; set; }

    /* The number of known indexes declared on the collection */
    [DataMember(Name = "countIndexes")]
    public int countIndexes { get; set; }

    }
  }
