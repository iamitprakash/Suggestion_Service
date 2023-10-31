using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
	public string GetData(int value)
	{
		return string.Format("You entered: {0}", value);
	}

	public CompositeType GetDataUsingDataContract(CompositeType composite)
	{
		if (composite == null)
		{
			throw new ArgumentNullException("composite");
		}
		if (composite.BoolValue)
		{
			composite.StringValue += "Suffix";
		}
		return composite;
	}

    public string InsertIdea(Idea ideaInfo)
    {
        string Message;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=Suggestions;Trusted_Connection=True;");
        con.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO [Suggestions].[dbo].[idea]" +
            " (Title,Descriptions,Expected_Dureation,Docs,Current_Status,createdby,createdat,modifiedBy,modifiedat) VALUES" +
            "(@Title,@Descriptions,@Expected_Dureation,@Docs,@Current_Status,@createdby,@createdat" +
            "@modifiedBy,@modifiedat)", con);
        cmd.Parameters.AddWithValue("@Title", ideaInfo.title);
        cmd.Parameters.AddWithValue("@Descriptions", ideaInfo.description);
        cmd.Parameters.AddWithValue("@Expected_Dureation", ideaInfo.expected_Dureation);
        cmd.Parameters.AddWithValue("@Docs", ideaInfo.docs);
        cmd.Parameters.AddWithValue("@Current_Status", ideaInfo.current_Status);
        cmd.Parameters.AddWithValue("@createdby", ideaInfo.createdby);
        cmd.Parameters.AddWithValue("@createdat", ideaInfo.createdat);
        cmd.Parameters.AddWithValue("@modifiedBy", ideaInfo.modifiedby);
        cmd.Parameters.AddWithValue("@modifiedat", ideaInfo.modifiedat);
        int result = cmd.ExecuteNonQuery();
        if (result == 1)
        {
            Message = "Your Idea with title "+ideaInfo.Title + " has been submitted successfully";
        }
        else
        {
            Message = "You are unable to submit this "+ideaInfo.title + " at this time, please check with your Manager";
        }
        con.Close();
        return Message;
    }
}
