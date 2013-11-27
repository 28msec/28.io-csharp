using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _28.io.Project.Model {

  [DataContract(Name = "CollectionList28IO")]
  public class CollectionList28IO {
    /* The link to the first page of this collection item listing. Its offset is always 1, its limit is the same as the current request. It is present only if the the current offset is greater than 1 */
    [DataMember(Name = "first")]
    public string first { get; set; }

    /* The link to the previous page of this collection item listing. Its offset is the maximum among 1 and the current offset minus the current limit. It is present only if the the current offset is greater than 1 */
    [DataMember(Name = "previous")]
    public string previous { get; set; }

    /* The link to this collection item listing, with the same offset and limit */
    [DataMember(Name = "href")]
    public string href { get; set; }

    /* The link to the next page of this collection item listing.  Its offset is the sum of the current offset and the current limit. It is present only if the last item contained in the response is not the last one in the collection */
    [DataMember(Name = "next")]
    public string next { get; set; }

    /* The link to the last page of this collection item listing. Its offset is the biggest number smaller or equal to the number of items in the collection which can be obtained adding one or more times the current limit to the current offset. The limit is the same as the current page. It is present only if the last item contained in the response is not the last one in the collection */
    [DataMember(Name = "last")]
    public string last { get; set; }

    /* The requested offset */
    [DataMember(Name = "offset")]
    public int offset { get; set; }

    /* The requested limit */
    [DataMember(Name = "limit")]
    public int limit { get; set; }

    /* The declared type of the items in the collection */
    [DataMember(Name = "count")]
    public int count { get; set; }

    /* The list of item starting whose position (starting from 1) in the collection is between offset(included) and offset+limit (excluded) */
    [DataMember(Name = "items")]
    public List<Item28IO> items { get; set; }

    }
  }
