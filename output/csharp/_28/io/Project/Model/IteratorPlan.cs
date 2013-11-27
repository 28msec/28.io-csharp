using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace _28.io.Project.Model {

  [DataContract(Name = "IteratorPlan")]
  public class IteratorPlan {
    /* The iterator kind */
    [DataMember(Name = "kind")]
    public string kind { get; set; }

    /* The plan of nested iterators */
    [DataMember(Name = "iterators")]
    public List<IteratorPlan> iterators { get; set; }

    /* The allow-atomics iterator property */
    [DataMember(Name = "allow-atomics")]
    public string allow_atomics { get; set; }

    /* The ascending iterator property */
    [DataMember(Name = "ascending")]
    public string ascending { get; set; }

    /* The attr_cont iterator property */
    [DataMember(Name = "attr_cont")]
    public string attr_cont { get; set; }

    /* The cached iterator property */
    [DataMember(Name = "cached")]
    public string cached { get; set; }

    /* The check-only iterator property */
    [DataMember(Name = "check-only")]
    public string check_only { get; set; }

    /* The copyInputNodes iterator property */
    [DataMember(Name = "copyInputNodes")]
    public string copyInputNodes { get; set; }

    /* The distinct iterator property */
    [DataMember(Name = "distinct")]
    public string distinct { get; set; }

    /* The doc_test_kind iterator property */
    [DataMember(Name = "doc_test_kind")]
    public string doc_test_kind { get; set; }

    /* The function iterator property */
    [DataMember(Name = "function")]
    public string function { get; set; }

    /* The id iterator property */
    [DataMember(Name = "id")]
    public string id { get; set; }

    /* The inputVar iterator property */
    [DataMember(Name = "inputVar")]
    public string inputVar { get; set; }

    /* The is-dynamic iterator property */
    [DataMember(Name = "is-dynamic")]
    public string is_dynamic { get; set; }

    /* The materialize iterator property */
    [DataMember(Name = "materialize")]
    public string materialize { get; set; }

    /* The name iterator property */
    [DataMember(Name = "name")]
    public string name { get; set; }

    /* The need-to-copy iterator property */
    [DataMember(Name = "need-to-copy")]
    public string need_to_copy { get; set; }

    /* The nill allowed iterator property */
    [DataMember(Name = "nill allowed")]
    public string nill_allowed { get; set; }

    /* The pos-referenced-by iterator property */
    [DataMember(Name = "pos-referenced-by")]
    public string pos_referenced_by { get; set; }

    /* The qname iterator property */
    [DataMember(Name = "qname")]
    public string qname { get; set; }

    /* The quant iterator property */
    [DataMember(Name = "quant")]
    public string quant { get; set; }

    /* The referenced-by iterator property */
    [DataMember(Name = "referenced-by")]
    public string referenced_by { get; set; }

    /* The skip iterator property */
    [DataMember(Name = "skip")]
    public string skip { get; set; }

    /* The target_position iterator property */
    [DataMember(Name = "target_position")]
    public string target_position { get; set; }

    /* The targetPos iterator property */
    [DataMember(Name = "targetPos")]
    public string targetPos { get; set; }

    /* The test kind iterator property */
    [DataMember(Name = "test kind")]
    public string test_kind { get; set; }

    /* The type iterator property */
    [DataMember(Name = "type")]
    public string type { get; set; }

    /* The typename iterator property */
    [DataMember(Name = "typename")]
    public string typename { get; set; }

    /* The value iterator property */
    [DataMember(Name = "value")]
    public string value { get; set; }

    /* The varid iterator property */
    [DataMember(Name = "varid")]
    public string varid { get; set; }

    /* The varkind iterator property */
    [DataMember(Name = "varkind")]
    public string varkind { get; set; }

    /* The varname iterator property */
    [DataMember(Name = "varname")]
    public string varname { get; set; }

    }
  }
