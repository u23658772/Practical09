use ScocialClub
go

CREATE TABLE [dbo].[Members](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NOT NULL,
	[ClubName] [varchar](400) NOT NULL,
	[Age] [int] NOT NULL,
	[Fee] [decimal](6,2) NOT NULL,
 CONSTRAINT [PK_Name] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

select * from Members
go

Select Members.ID, Members.Name, Members.ClubName, Members.Age, Members.Fee from Members where Members.ID = '4'
go