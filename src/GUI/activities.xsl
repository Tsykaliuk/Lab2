<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" />
	<xsl:template match="/">
		<html>
			<body>
				<h2>student_activities</h2>
				<table border="2">
					<tr bgcolor="#fff">
						<th>Title</th>
						<th>Faculty</th>
						<th>Department</th>
						<th>Schedule</th>
						<th>Leader</th>
						<th>Starosta</th>
					</tr>
					<xsl:for-each select="//Club">
						<tr>
							<td>
								<xsl:value-of select="Title"/>
							</td>
							<td>
								<xsl:value-of select="Faculty"/>
							</td>
							<td>
								<xsl:value-of select="Department"/>
							</td>
							<td>
								<xsl:value-of select="Schedule"/>
							</td>
							<td>
								<xsl:value-of select="Leader"/>
							</td>
							<td>
								<xsl:value-of select="Starosta"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
			</body>
		</html>
	</xsl:template>
</xsl:stylesheet>