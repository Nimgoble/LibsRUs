/*
    What we need to be able to search:
    -Search input textbox
    -URL to acquire the list of tags from
    -URL to acquire the HTML for the selected result
    -Tag container to append the selected tag to
*/
(
    function ($)
    {
        $.tagSearch = function (element, tagsListURL, tagHTMLURL, tagContainer)
        {
            var plugin = this;

            plugin.tagsListURL = tagsListURL;
            plugin.tagHTMLURL = tagHTMLURL;
            plugin.tagContainer = tagContainer;

            var $element = $(element),
                element = element;

            $element.autocomplete
            (
                {
                    source: function (request, response)
                    {
                        $.ajax(
                        {
                            url: tagsListURL,
                            dataType: "json",
                            data:
                            {
                                term: request.term
                            },
                            success: function (data)
                            {
                                response(data);
                            }
                        });
                    },
                    select: function (event, ui)
                    {
                        if (ui.item !== null)
                        {
                            selectTag(ui.item.value);
                            $element.val('');
                            return false;
                        }
                        else
                        {
                            $element.removeClass("field-validation-valid").addClass("field-validation-error");
                        }
                    }
                }
            );

            $(tagContainer).on
            (
                'click',
                '.libTagItem',
                function ()
                {
                    $(this).closest('.libTagItem').hide('blind', function () { $(this).remove(); });
                    return false;
                }
            );

            function selectTag(tagText)
            {
                var jsonObject =
                {
                    "text": tagText
                };

                $.ajax
                (
                    {
                        url: tagHTMLURL,
                        contentType: 'application/json; charset=utf-8',
                        data: jsonObject,
                        dataType: "html",
                        cache: false,
                        success: insertTag
                    }
                );
                return false;
            }

            function insertTag(data)
            {
                var cl = $(tagContainer);
                cl.append(data);
                var terms = cl.find('.libTagItem');
                terms.last().hide().show('blind');
            }
        };

        $.fn.tagSearch = function(tagsListURL, tagHTMLURL, tagContainer)
        {
            return this.each
            (
                function()
                {
                    if(undefined == $(this).data('tagSearch'))
                    {
                        var plugin = new $.tagSearch(this, tagsListURL, tagHTMLURL, tagContainer);
                        $(this).data('tagSearch', plugin);
                    }
                }
            );
        }
    }(jQuery)
);