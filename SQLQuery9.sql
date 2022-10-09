SELECT [StuName],avg(CONVERT(INT, Marks)) as grade
                            from [dbo].[StudentInfo]
							where ClassName = 'one'
							group by [StuName];