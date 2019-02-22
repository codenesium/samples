import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import FileMapper from './fileMapper';
import FileViewModel from './fileViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface FileEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface FileEditComponentState {
  model?: FileViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class FileEditComponent extends React.Component<
  FileEditComponentProps,
  FileEditComponentState
> {
  state = {
    model: new FileViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
	submitted:false
  };

    componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Files +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.FileClientResponseModel;

          console.log(response);

          let mapper = new FileMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });

		  this.props.form.setFieldsValue(mapper.mapApiResponseToViewModel(response));
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: false,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
 }
 
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
      .put(
        Constants.ApiEndpoint + ApiRoutes.Files + '/' + this.state.model!.id,
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
              {getFieldDecorator('bucketId', {
              rules:[],
              
              })
              ( <Input placeholder={"BucketId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='dateCreated'>DateCreated</label>
              <br />             
              {getFieldDecorator('dateCreated', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
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
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"Expiration"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='extension'>Extension</label>
              <br />             
              {getFieldDecorator('extension', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
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
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"ExternalId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fileSizeInByte'>FileSizeInByte</label>
              <br />             
              {getFieldDecorator('fileSizeInByte', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <InputNumber placeholder={"FileSizeInByte"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='fileTypeId'>FileTypeId</label>
              <br />             
              {getFieldDecorator('fileTypeId', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"FileTypeId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='location'>Location</label>
              <br />             
              {getFieldDecorator('location', {
              rules:[{ required: true, message: 'Required' },
{ whitespace: true, message: 'Required' },
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
{ whitespace: true, message: 'Required' },
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
{ whitespace: true, message: 'Required' },
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

export const WrappedFileEditComponent = Form.create({ name: 'File Edit' })(FileEditComponent);

/*<Codenesium>
    <Hash>59410d8b74739e15da461444f0939d04</Hash>
</Codenesium>*/