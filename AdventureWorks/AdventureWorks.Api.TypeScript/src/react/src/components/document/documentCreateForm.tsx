import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DocumentMapper from './documentMapper';
import DocumentViewModel from './documentViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface DocumentCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface DocumentCreateComponentState {
  model?: DocumentViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class DocumentCreateComponent extends React.Component<
  DocumentCreateComponentProps,
  DocumentCreateComponentState
> {
  state = {
    model: new DocumentViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

 handleSubmit = (e:FormEvent<HTMLFormElement>) => {
     e.preventDefault();
     this.props.form.validateFields((err:any, values:any) => {
      if (!err) {
        let model = values as DocumentViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:DocumentViewModel) =>
  {  
    let mapper = new DocumentMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Documents,
        mapper.mapViewModelToApiRequest(model),
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as CreateResponse<
            Api.DocumentClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
          this.setState({...this.state, submitted:true, errorOccurred:true, errorMessage:'Error from API'});
        }
      ); 
  }
  
  render() {

    const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        
    let message:JSX.Element = <div></div>;
    if(this.state.submitted)
    {
      if (this.state.errorOccurred) {
        message = <Alert message={this.state.errorMessage} type='error' />;
      }
      else
      {
        message = <Alert message='Submitted' type='success' />;
      }
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='changeNumber'>ChangeNumber</label>
              <br />             
              {getFieldDecorator('changeNumber', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ChangeNumber"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='document1'>Document</label>
              <br />             
              {getFieldDecorator('document1', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Document"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='documentLevel'>DocumentLevel</label>
              <br />             
              {getFieldDecorator('documentLevel', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"DocumentLevel"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='documentSummary'>DocumentSummary</label>
              <br />             
              {getFieldDecorator('documentSummary', {
              rules:[],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"DocumentSummary"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fileExtension'>FileExtension</label>
              <br />             
              {getFieldDecorator('fileExtension', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 8, message: 'Exceeds max length of 8' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"FileExtension"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fileName'>FileName</label>
              <br />             
              {getFieldDecorator('fileName', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 400, message: 'Exceeds max length of 400' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"FileName"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='folderFlag'>FolderFlag</label>
              <br />             
              {getFieldDecorator('folderFlag', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"FolderFlag"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='modifiedDate'>ModifiedDate</label>
              <br />             
              {getFieldDecorator('modifiedDate', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"ModifiedDate"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='owner'>Owner</label>
              <br />             
              {getFieldDecorator('owner', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Owner"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='revision'>Revision</label>
              <br />             
              {getFieldDecorator('revision', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 5, message: 'Exceeds max length of 5' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Revision"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='status'>Status</label>
              <br />             
              {getFieldDecorator('status', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Status"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='title'>Title</label>
              <br />             
              {getFieldDecorator('title', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
{ max: 50, message: 'Exceeds max length of 50' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"Title"} /> )}
              </Form.Item>

			
          <Form.Item>
            <Button type="primary" htmlType="submit">
                Submit
              </Button>
            </Form.Item>
			{message}
        </Form>);
    } else {
      return null;
    }
  }
}

export const WrappedDocumentCreateComponent = Form.create({ name: 'Document Create' })(DocumentCreateComponent);

/*<Codenesium>
    <Hash>eb3c11e9c4a501c605f09b945e8e2654</Hash>
</Codenesium>*/