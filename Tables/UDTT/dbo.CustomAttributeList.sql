﻿-- Custom Attribute List UDTT for uploading CustomAttributes
CREATE TYPE [dbo].[CustomAttributeList] AS TABLE
(
	[Key] VARCHAR(64) NOT NULL,
	[Value] VARCHAR(512) NOT NULL
)