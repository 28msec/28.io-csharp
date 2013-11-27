using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _28.io.Project.Model {

  [DataContract(Name = "ProjectTokens")]
  public class ProjectTokens {
    /* The token for the project {name}. One field for each project owned by the account will be present */
    [DataMember(Name = "project_{name}")]
    public string project__name_ { get; set; }

    }
  }
