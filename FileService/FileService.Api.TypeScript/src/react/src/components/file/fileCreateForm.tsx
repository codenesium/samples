import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { ActionResponse, CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FileMapper from './fileMapper';
import FileViewModel from './fileViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ToLowerCaseFirstLetter } from '../../lib/stringUtilities';
import { BucketSelectComponent } from '../shared/bucketSelect'
	import { FileTypeSelectComponent } from '../shared/fileTypeSelect'
	
interface FileCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface FileCreateComponentState {
  model?: FileViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class FileCreateComponent extends React.Component<
  FileCreateComponentProps,
  FileCreateComponentState
> {
  state = {
    model: new FileViewModel(),
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
        let model = values as FileViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:FileViewModel) =>
  {  
    let mapper = new FileMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Files,
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
            Api.FileClientRequestModel
          >;
          this.setState({...this.state, submitted:true, model:mapper.mapApiResponseToViewModel(response.record!), errorOccurred:false, errorMessage:''});
          console.log(response);
        },
        error => {
          console.log(error);
		   let errorResponse = error.response.data as ActionResponse; 

          errorResponse.validationErrors.forEach(x =>
          {
            this.props.form.setFields({
             [ToLowerCaseFirstLetter(x.propertyName)]: {
              value:this.props.form.getFieldValue(ToLowerCaseFirstLetter(x.propertyName)),
              errors: [new Error(x.errorMessage)]
            },
            })
          });
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
                        <label htmlFor='bucketId'>BucketId</label>
                        <br />   
                        <BucketSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.Buckets}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="bucketId"
                          required={false}
                          selectedValue={this.state.model!.bucketId}
                         />
                        </Form.Item>

						<Form.Item>
              <label htmlFor='dateCreated'>DateCreated</label>
              <br />             
              {getFieldDecorator('dateCreated', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"DateCreated"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='description'>Description</label>
              <br />             
              {getFieldDecorator('description', {
              rules:[{ max: 255, message: 'Exceeds max length of 255' },
],
              
              })
              ( <Input placeholder={"Description"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='expiration'>Expiration</label>
              <br />             
              {getFieldDecorator('expiration', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"Expiration"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='extension'>Extension</label>
              <br />             
              {getFieldDecorator('extension', {
              rules:[{ required: true, message: 'Required' },
{ max: 32, message: 'Exceeds max length of 32' },
],
              
              })
              ( <Input placeholder={"Extension"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='externalId'>ExternalId</label>
              <br />             
              {getFieldDecorator('externalId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"ExternalId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fileSizeInByte'>FileSizeInByte</label>
              <br />             
              {getFieldDecorator('fileSizeInByte', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <InputNumber placeholder={"FileSizeInByte"} /> )}
              </Form.Item>

						
                        <Form.Item>
                        <label htmlFor='fileTypeId'>FileTypeId</label>
                        <br />   
                        <FileTypeSelectComponent   
                          apiRoute={
                          Constants.ApiEndpoint +
                          ApiRoutes.FileTypes}
                          getFieldDecorator={this.props.form.getFieldDecorator}
                          propertyName="fileTypeId"
                          required={true}
                          selectedValue={this.state.model!.fileTypeId}
                         />
                        </Form.Item>

						<Form.Item>
              <label htmlFor='location'>Location</label>
              <br />             
              {getFieldDecorator('location', {
              rules:[{ required: true, message: 'Required' },
{ max: 255, message: 'Exceeds max length of 255' },
],
              
              })
              ( <Input placeholder={"Location"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='privateKey'>PrivateKey</label>
              <br />             
              {getFieldDecorator('privateKey', {
              rules:[{ required: true, message: 'Required' },
{ max: 64, message: 'Exceeds max length of 64' },
],
              
              })
              ( <Input placeholder={"PrivateKey"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='publicKey'>PublicKey</label>
              <br />             
              {getFieldDecorator('publicKey', {
              rules:[{ required: true, message: 'Required' },
{ max: 64, message: 'Exceeds max length of 64' },
],
              
              })
              ( <Input placeholder={"PublicKey"} /> )}
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

export const WrappedFileCreateComponent = Form.create({ name: 'File Create' })(FileCreateComponent);

/*<Codenesium>
    <Hash>7d85dbd835b258201e583ff9cb67c85a</Hash>
</Codenesium>*/