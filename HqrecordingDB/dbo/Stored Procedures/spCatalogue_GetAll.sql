-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[spCatalogue_GetAll]

	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
SELECT        Id, Title, [Description], [Image], ArtistId, Price, Tracklength, DateCreated, DatePublished, ParentId, SoundCatId
FROM            Catalogue


END