SELECT * FROM [RbrDb_267].[dbo].[CustomerAcct]
  where [RbrDb_267].[dbo].[CustomerAcct].[routing_plan_id] in (1,2,3,4,5,6,8,11,13,16,17,18,20)



DELETE
  FROM [RbrDb_267].[dbo].[RoutingPlan]
  where [RbrDb_267].[dbo].[RoutingPlan].[routing_plan_id] in (1,2,3,4,5,6,8,11,13,16,17,18,20)