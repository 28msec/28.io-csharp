using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _28.io.Project.Model {

  [DataContract(Name = "Item28IO")]
  public class Item28IO {
    /* The item content-type, if different from the default one */
    [DataMember(Name = "contentType")]
    public string contentType { get; set; }

    /* A link that can be used to refer to the item. It is present only for items which are stored in a MongoDB collection */
    [DataMember(Name = "href")]
    public string href { get; set; }

    /* The item serialized using the "json+xml hybrid" serialization method */
    [DataMember(Name = "content")]
    public string content { get; set; }

    }
  }
