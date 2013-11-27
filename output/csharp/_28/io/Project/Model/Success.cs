using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _28.io.Project.Model {

  [DataContract(Name = "Success")]
  public class Success {
    [DataMember(Name = "success")]
    public bool success { get; set; }

    }
  }
