// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var suggestedParts = {
    appendImage: function (part, tr) {
        $('<td>').html($('<img>')
            .attr('src', '/images/' + part['partType']['name'] + '.jpg')
            .attr('width', 100).attr('height', 100)).appendTo(tr)
    },
    appendSpecificInfo: function (part, tr) {
        var td = $('<td>');

        switch (part['partType']['name']) {
            case 'data_storage':
                $('<p>').text(part['memoryGb'] + ' GB').appendTo(td);
                $('<p>').text(part['type']).appendTo(td);
                $('<p>').text(part['dataStorageInterface']).appendTo(td);
                $('<p>').text('Ilgis ' + part['length']).appendTo(td);
                break;
            case 'ram':
                $('<p>').text(part['memoryGb'] + ' GB').appendTo(td);
                $('<p>').text(part['connectionType']).appendTo(td);
                $('<p>').text(part['type']).appendTo(td);
                break;
            case 'processor':
                $('<p>').text(part['connectionType']).appendTo(td);
                $('<p>').text(part['processorFrequency'] + ' Ghz').appendTo(td);
                $('<p>').text(part['coreCount'] + ' branduoliai').appendTo(td);
                $('<p>').text(part['power'] + ' W').appendTo(td);
                break;
            case 'computer_case':
                $('<p>').text(part['width'] + ' x ' + part['length'] + ' x ' + part['height']).appendTo(td);
                $('<p>').text(part['color']).appendTo(td);
                break;
            case 'motherboard':
                $('<p>').text('Ram jungtis: ' + part['ramConnType']).appendTo(td);
                $('<p>').text('Ram jungt. sk.: ' + part['ramSocketCount']).appendTo(td);
                $('<p>').text('Ram palaikymas: ' + part['maxRam'] + ' GB').appendTo(td);
                $('<p>').text('CPU jungtis: ' + part['cpuConnType']).appendTo(td);
                $('<p>').text('Ilgis: ' + part['length'] + " cm").appendTo(td);
                break;
            case 'gpu':
                $('<p>').text(part['memoryGb']).appendTo(td);
                $('<p>').text(part['type']).appendTo(td);
                $('<p>').text(part['power'] + ' GB').appendTo(td);
                $('<p>').text('Ilgis: ' + part['length'] + ' cm').appendTo(td);
                $('<p>').text('Palaiko: ' + part['monitorSocketCount'] + " ekr.").appendTo(td);
                break;
            case 'psu':
                $('<p>').text(part['power'] + ' GB').appendTo(td);
                $('<p>').text(part['efficiencyRating']).appendTo(td);
                $('<p>').text('Jungt. skaičius: ' + part['pciSocketCount']).appendTo(td);
                $('<p>').text('Ilgis: ' + part['length'] + " ekr.").appendTo(td);
                break;
        }
        td.appendTo(tr);
    },
    appendCommonInfo: function (part, tr) {
        $('<td>').text(part['manufacturer']).appendTo(tr);
        $('<td>').text(part['model']).appendTo(tr);
        $('<td>').text(part['code']).appendTo(tr);
        $('<td>').text(part['price']).appendTo(tr);
        $('<td>').text(part['qty']).appendTo(tr);
    }
}

$('.pc-parts').on('change', 'select', function () {
    var partIds = [];
    $('.pc-parts select').each(function () {
        partIds.push($(this).val());
    });

    $.ajax({
        type: "POST",
        url: "/Parts/RelatedParts",
        data: { PIds: partIds },
        datatype: "json",
        success: function (result) {
            var suggestedContainer = $('.suggested-parts-row');
            var suggestedInner = $('.suggested-parts');
            suggestedInner.empty();

            if (result.length > 0) {
                result.forEach(function (part) {
                    var tr = $('<tr>');
                    suggestedParts.appendImage(part, tr);
                    suggestedParts.appendSpecificInfo(part, tr);
                    suggestedParts.appendCommonInfo(part, tr);
                    tr.appendTo(suggestedInner);
                });
                suggestedContainer.removeClass("hidden")
            } else {
                result.length > 0 ? suggestedContainer.removeClass("hidden") : suggestedContainer.addClass("hidden");
            }
        },
        error: function (xmlhttprequest, textstatus, errorthrown) {
            console.log("error: " + errorthrown);
        }
    });
})
