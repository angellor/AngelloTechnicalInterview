# ReadingCorpBookAPI

## References used during implentation

<table data-number-column="false"><colgroup><col style="width: 222px;"><col style="width: 582px;"><col style="width: 153px;"></colgroup><tbody><tr><th rowspan="1" colspan="1" colorname="" class="ak-renderer-tableHeader-sortable-column" data-colwidth="223"><p data-renderer-start-pos="4"><strong data-renderer-mark="true">Area</strong></p><figure class="ak-renderer-tableHeader-sorting-icon ak-renderer-tableHeader-sorting-icon__no-order"><div role="presentation"><figure class="sc-hizQCF kWpuKU"><div class="sorting-icon-svg__no_order table-sorting-icon-inactive sc-eNPDpu cohKdl"></div></figure></div></figure></th><th rowspan="1" colspan="1" colorname="" class="ak-renderer-tableHeader-sortable-column" data-colwidth="583"><p data-renderer-start-pos="12"><strong data-renderer-mark="true">Issue</strong></p><figure class="ak-renderer-tableHeader-sorting-icon ak-renderer-tableHeader-sorting-icon__no-order"><div role="presentation"><figure class="sc-hizQCF kWpuKU"><div class="sorting-icon-svg__no_order table-sorting-icon-inactive sc-eNPDpu cohKdl"></div></figure></div></figure></th><th rowspan="1" colspan="1" colorname="" class="ak-renderer-tableHeader-sortable-column" data-colwidth="154"><p data-renderer-start-pos="21"><strong data-renderer-mark="true">Reference</strong></p><figure class="ak-renderer-tableHeader-sorting-icon ak-renderer-tableHeader-sorting-icon__no-order"><div role="presentation"><figure class="sc-hizQCF kWpuKU"><div class="sorting-icon-svg__no_order table-sorting-icon-inactive sc-eNPDpu cohKdl"></div></figure></div></figure></th></tr><tr><td rowspan="1" colspan="1" colorname="" data-colwidth="223"><p data-renderer-start-pos="36">Adding CORS</p></td><td rowspan="1" colspan="1" colorname="" data-colwidth="583"><p data-renderer-start-pos="51">Had an issue with CORS and it was not working until I read a comment in on one of the post in this link. This is the line of code that helped</p><p data-renderer-start-pos="191"><code class="code css-9z42f9" data-renderer-mark="true">.SetIsOriginAllowed((host) =&gt; true)</code></p></td><td rowspan="1" colspan="1" colorname="" data-colwidth="154"><p data-renderer-start-pos="230"><span data-inline-card="true" data-card-url="https://stackoverflow.com/questions/44379560/how-to-enable-cors-in-asp-net-core-webapi"><span class="loader-wrapper"><a class="sc-hGoxap jNvnOk" href="https://stackoverflow.com/questions/44379560/how-to-enable-cors-in-asp-net-core-webapi" tabindex="0" role="button" data-testid="inline-card-resolved-view"><span class="sc-fhYwyz kKiYQE"><span class="sc-bMvGRv kspDbK"><span class="sc-CtfFt eiSvVh"></span></span><span class="sc-laTMn fJphvA">How to enable CORS in ASP.net Core WebAPI</span></span></a></span></span> </p></td></tr><tr><td rowspan="1" colspan="1" colorname="" data-colwidth="223"><p data-renderer-start-pos="238">Exclude Property on Update in Entity Framework</p></td><td rowspan="1" colspan="1" colorname="" data-colwidth="583"><p data-renderer-start-pos="288">I did not want the API to overwrite the Registration Date of a book so I found out how to mark the field so it does not get updated and that is in my BookRepo implementation in my update method.</p></td><td rowspan="1" colspan="1" colorname="" data-colwidth="154"><p data-renderer-start-pos="486"><span data-inline-card="true" data-card-url="https://stackoverflow.com/questions/12661881/exclude-property-on-update-in-entity-framework"><span class="loader-wrapper"><a class="sc-hGoxap jNvnOk" href="https://stackoverflow.com/questions/12661881/exclude-property-on-update-in-entity-framework" tabindex="0" role="button" data-testid="inline-card-resolved-view"><span class="sc-fhYwyz kKiYQE"><span class="sc-bMvGRv kspDbK"><span class="sc-CtfFt eiSvVh"></span>></span><span class="sc-laTMn fJphvA">Exclude Property on Update in Entity Framework</span></span></a></span></span> </p></td></tr><tr><td rowspan="1" colspan="1" colorname="" data-colwidth="223"><p data-renderer-start-pos="494">Repository pattern</p></td><td rowspan="1" colspan="1" colorname="" data-colwidth="583"><p data-renderer-start-pos="515">Brushed up on my repo pattern knowing that I wanted to use it in my implementation of the Web API</p></td><td rowspan="1" colspan="1" colorname="" data-colwidth="154"><p data-renderer-start-pos="615"><span data-inline-card="true" data-card-url="https://www.pragimtech.com/blog/blazor/rest-api-repository-pattern/"><span class="loader-wrapper"><a class="sc-hGoxap jNvnOk" href="https://www.pragimtech.com/blog/blazor/rest-api-repository-pattern/" tabindex="0" role="button" data-testid="inline-card-resolved-view"><span class="sc-fhYwyz kKiYQE"><span class="sc-bMvGRv kspDbK"><span class="sc-CtfFt eiSvVh"></span><span class="sc-bnXvFD koCwvd"><span data-testid="inline-card-icon-and-title-default" role="img" aria-label="link" class="css-gtvrz1"><svg width="24" height="24" viewBox="0 0 24 24" role="presentation"><g fill="currentColor" fill-rule="evenodd"><path d="M12.856 5.457l-.937.92a1.002 1.002 0 000 1.437 1.047 1.047 0 001.463 0l.984-.966c.967-.95 2.542-1.135 3.602-.288a2.54 2.54 0 01.203 3.81l-2.903 2.852a2.646 2.646 0 01-3.696 0l-1.11-1.09L9 13.57l1.108 1.089c1.822 1.788 4.802 1.788 6.622 0l2.905-2.852a4.558 4.558 0 00-.357-6.82c-1.893-1.517-4.695-1.226-6.422.47"></path><path d="M11.144 19.543l.937-.92a1.002 1.002 0 000-1.437 1.047 1.047 0 00-1.462 0l-.985.966c-.967.95-2.542 1.135-3.602.288a2.54 2.54 0 01-.203-3.81l2.903-2.852a2.646 2.646 0 013.696 0l1.11 1.09L15 11.43l-1.108-1.089c-1.822-1.788-4.802-1.788-6.622 0l-2.905 2.852a4.558 4.558 0 00.357 6.82c1.893 1.517 4.695 1.226 6.422-.47"></path></g></svg></span></span></span><span class="sc-laTMn fJphvA">Repository Pattern in ASP.NET Core REST API</span></span></a></span></span> </p></td></tr></tbody></table>


## Data Persistance
Sqlite is used to persist data in this solution. It is saved in the folder BookAPI with a name of 'bookcatalog.db'.
Entity Frameworkcore is used to interact with the Sqlite database.

## Launching Project
Ensure that the solution lauches both the BookCatalogUI project and the BookAPI project. at the same time. This will allow the UI to make its calls to the  Web API.
