using System;
using DnsClient.Protocol;

namespace Catalog.Core.Specs;

public class CatalogSpecParams
{
    private const int MAXPAGESIZE = 70;
    private int _pageSize = 10;
    public int PageIndex { get; set; } = 1;
    
    public string? BrandId { get; set; }
    public string? TypeId { get; set; }
    public string? Sort { get; set; }
    public string? Search { get; set; }
    public int PageSize { 
        get => _pageSize;
        set => _pageSize = (value > MAXPAGESIZE)? MAXPAGESIZE : value;
        }
        
}
