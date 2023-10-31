using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

	[OperationContract]
	string GetData(int value);
    [OperationContract]
    string InsertIdea(Idea userInfo);
    [OperationContract]
	CompositeType GetDataUsingDataContract(CompositeType composite);

	// TODO: Add your service operations here
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.
[DataContract]
public class CompositeType
{
	bool boolValue = true;
	string stringValue = "Hello ";

	[DataMember]
	public bool BoolValue
	{
		get { return boolValue; }
		set { boolValue = value; }
	}

	[DataMember]
	public string StringValue
	{
		get { return stringValue; }
		set { stringValue = value; }
	}
}

public class Idea
{
	public string Title = String.Empty;
	public string Description= String.Empty;
	public string Expected_Dureation = String.Empty;
	public string Docs = String.Empty;
	public string Current_Status = String.Empty;
	public string createdby = "Default User";
	public DateTime createdat= DateTime.Now;
	public DateTime modifiedat = DateTime.Now;
	public string modifiedby = String.Empty;

	[DataMember]
	public string title
	{
		get { return Title; }
		set { Title = value; }
	}
    [DataMember]
    public string description
    {
        get { return Description; }
        set { Description = value; }
    }
    [DataMember]
    public string expected_Dureation
    {
        get { return Expected_Dureation; }
        set { Expected_Dureation = value; }
    }
    [DataMember]
    public string docs
    {
        get { return Docs; }
        set { Docs = value; }
    }
    [DataMember]
    public string current_Status
    {
        get { return Current_Status; }
        set { Current_Status = value; }
    }
    [DataMember]
    public string Createdby
    {
        get { return createdby; }
        set { createdby = value; }
    }
    [DataMember]
    public DateTime Createdat
    {
        get { return createdat; }
        set { createdat = value; }
    }
    [DataMember]
    public DateTime Modifiedat
    {
        get { return modifiedat; }
        set { modifiedat = value; }
    }
    [DataMember]
    public string Modifiedby
    {
        get { return modifiedby; }
        set { modifiedby = value; }
    }
}
