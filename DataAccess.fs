namespace DataAccess
open FSharp.Data.Sql


module UserStories =

  [<Literal>]
  let ResolutionPath = __SOURCE_DIRECTORY__ + "/libraries"
  
  [<Literal>]
  let ConnStr =  "Server=localhost;Database=project_planner;User=root;Pwd=hunter2;Convert Zero Datetime=true;"
  
  type Sql = SqlDataProvider<Common.DatabaseProviderTypes.MYSQL, ConnectionString = ConnStr, Owner = "project_planner", ResolutionPath = ResolutionPath>
  let ctx = Sql.GetDataContext()

  let getAllUserstories =   
    let allUserstories = 
      query {
        for us in ctx.ProjectPlanner.Userstories do
        select (us.Title)
      }
    Seq.toList allUserstories