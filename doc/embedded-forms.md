## html form example
**filename : diagram_1.html**
```
form role="form" name="testForm">
  <div class="form-group">
    <label for="customerId-field">Customer ID Value</label>
    <input required
           cam-variable-name="customerId"
           cam-variable-type="String"
           class="form-control" />
  </div>
  <div class="form-group">
    <label for="amount-field">Amount Value</label>
    <input cam-variable-name="amount"
           cam-variable-type="Double"
           class="form-control" />
  </div>
</form>
```



## VSCode Rest code

Multi-part POST operation to send bpmn and html file to Camunda

```
POST {{camundaRestEngine}}/deployment/create HTTP/1.1
Content-Type: multipart/form-data; boundary=28319d96a8c54b529aa9159ad75edef9
Accept: application/json

--28319d96a8c54b529aa9159ad75edef9
Content-Disposition: form-data; name="deployment-name"

test
--28319d96a8c54b529aa9159ad75edef9
Content-Disposition: form-data; name="enable-duplicate-filtering"

false
--28319d96a8c54b529aa9159ad75edef9
Content-Disposition: form-data; name="deploy-changed-only"

false
--28319d96a8c54b529aa9159ad75edef9
Content-Disposition: form-data; name="deployment-source"

process application
--28319d96a8c54b529aa9159ad75edef9
Content-Disposition: form-data; name="data"; filename="diagram_1.bpmn"
Content-Type: text/plain

< ./diagram_1.bpmn
--28319d96a8c54b529aa9159ad75edef9
Content-Disposition: form-data; name="data2"; filename="diagram_1.html"
Content-Type: text/plain

< ./diagram_1.html
--28319d96a8c54b529aa9159ad75edef9--
```

