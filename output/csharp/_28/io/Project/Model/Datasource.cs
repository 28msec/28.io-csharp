using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _28.io.Project.Model {

  [DataContract(Name = "Datasource")]
  public class Datasource {
    /* The datasource category */
    [DataMember(Name = "category")]
    public string category { get; set; }

    /* The datasource name */
    [DataMember(Name = "name")]
    public string name { get; set; }

    /* Whether the datasource is the default one in its category */
    [DataMember(Name = "default")]
    public bool _default { get; set; }

    }
  }
