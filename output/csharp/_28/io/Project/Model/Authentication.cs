using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _28.io.Project.Model {

  [DataContract(Name = "Authentication")]
  public class Authentication {
    /* The API token type */
    [DataMember(Name = "token_type")]
    public string token_type { get; set; }

    /* The expiration date of all the tokens in the response */
    [DataMember(Name = "expiration_date")]
    public DateTime expiration_date { get; set; }

    /* The API token */
    [DataMember(Name = "access_token")]
    public string access_token { get; set; }

    /* The refresh token which can be used to refresh both the API and project tokens */
    [DataMember(Name = "refresh_token")]
    public string refresh_token { get; set; }

    /* The project tokens which can be used to make request to the APIs on the project endpoints */
    [DataMember(Name = "project_tokens")]
    public ProjectTokens project_tokens { get; set; }

    }
  }
