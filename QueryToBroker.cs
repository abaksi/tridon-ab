using Tridion.ContentDelivery.DynamicContent.Query;
using Tridion.ContentDelivery.DynamicContent.Filters;
using Tridion.ContentDelivery.Meta;

[WebMethod]
public static string GetDynamicComp(string metaID)
{ 
  ComponentFactory cpf = new ComponentFactory();
  Query query = new Query();
  
  //16 for component, 32 for CTs, 64 for Page, here we are dealing with type 16 i.e. components only
  ItemTypeCriteria componentsOnly = new ItemTypeCriteria(ItemType.Component.GetHashCode());
  SchemaTitleCriteria basedOnSchema = new SchemaTitleCriteria(“Schema Name”);
  PublicationCriteria basedOnPublication = new PublicationCriteria(pubId); //pubId needs to be provided
  Criteria criteria = CriteriaFactory.And(new Criteria[] { componentsOnly, basedOnSchema, basedOnPublication });
  
  //Setting Criteria for the query object, Schema Name, Pub Ids etc
  query.Criteria = criteria;
  
  //Condition for latest published item for multiple returns
  SortParameter sortParameter = new SortParameter(
  SortParameter.ItemLastPublishedDate,
  SortParameter.Descending);
  query.AddSorting(sortParameter);
  
  //Executes Query on DB
  var results = query.ExecuteQuery().ToList();
  
  List<IComponent> listCmp= new List<IComponent>();
  if (results != null && results.Count > 0)
  {
  foreach (string tcmId in results)
  {
      listCmp.Add(cpf.GetComponent(tcmId));
  }
  
  //Check for null before looping
  foreach (var item in  listCmp)
  {
  if (item.MetadataFields.ContainsKey(“Metadata Field Name”))
  {
  string URL= item.Multimedia.Url;
  string val=item.MetadataFields[“Metadata Field Name”].Value;
  }

}
