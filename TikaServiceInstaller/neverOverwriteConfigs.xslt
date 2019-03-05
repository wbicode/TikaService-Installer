<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:msxsl="urn:schemas-microsoft-com:xslt"
                xmlns:wix="http://schemas.microsoft.com/wix/2006/wi"
                exclude-result-prefixes="msxsl wix">
  <xsl:output method="xml" indent="yes" />

  <xsl:template match="node()|@*">
    <xsl:copy>
      <xsl:apply-templates select="node()|@*"/>
    </xsl:copy>
  </xsl:template>

 <xsl:template match="//*[local-name()='Component']">
    <wix:Component Id="{@Id}" Guid="{@Guid}">
      <xsl:if test="contains(*[local-name()='File']/@Source, '.config')">
        <xsl:attribute name="NeverOverwrite">yes</xsl:attribute>
        <xsl:attribute name="Permanent">yes</xsl:attribute>
      </xsl:if>
      <xsl:apply-templates select="@* | node()"/>
    </wix:Component>
  </xsl:template>

  <xsl:template match="@KeyPath">
    <xsl:choose>
      <xsl:when test="contains(parent::node()/@Source, '.config')">
        <xsl:attribute name="KeyPath">
          <xsl:value-of select="'yes'"/>
        </xsl:attribute>
      </xsl:when>
    </xsl:choose>
  </xsl:template>
</xsl:stylesheet>