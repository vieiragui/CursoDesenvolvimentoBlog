function Edit(event) {
    var lineTable = $(event).closest("tr");

    var id = lineTable.find("td:eq(0)").text().trim();
    var title = lineTable.find("td:eq(1)").text().trim();
    var resume = lineTable.find("td:eq(3)").text().trim();
    var content = lineTable.find("td:eq(5)").text().trim();
    // var status = lineTable.find("td:eq(7)").text().trim();

    console.log("Id: " + id);
    console.log("Title: " + title);
    console.log("Resume: " + resume);
    console.log("Content: " + content);

    $("#id").val(id);
    $("#title").val(title);
    $("#resume").val(resume);
    $("#content").val(content);
    // $("#status").val(status);
}