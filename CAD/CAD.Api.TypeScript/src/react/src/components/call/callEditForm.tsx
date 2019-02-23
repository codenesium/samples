import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CallMapper from './callMapper';
import CallViewModel from './callViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface CallEditComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface CallEditComponentState {
  model?: CallViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class CallEditComponent extends React.Component<
  CallEditComponentProps,
  CallEditComponentState
> {
  state = {
    model: new CallViewModel(),
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
          ApiRoutes.Calls +
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
          let response = resp.data as Api.CallClientResponseModel;

          console.log(response);

          let mapper = new CallMapper();

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
        let model = values as CallViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:CallViewModel) =>
  {  
    let mapper = new CallMapper();
     axios
      .put(
        Constants.ApiEndpoint + ApiRoutes.Calls + '/' + this.state.model!.id,
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
            Api.CallClientRequestModel
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
              <label htmlFor='addressId'>addressId</label>
              <br />             
              {getFieldDecorator('addressId', {
              rules:[],
              
              })
              ( <Input placeholder={"addressId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='callDispositionId'>callDispositionId</label>
              <br />             
              {getFieldDecorator('callDispositionId', {
              rules:[],
              
              })
              ( <Input placeholder={"callDispositionId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='callStatusId'>callStatusId</label>
              <br />             
              {getFieldDecorator('callStatusId', {
              rules:[],
              
              })
              ( <Input placeholder={"callStatusId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='callString'>callString</label>
              <br />             
              {getFieldDecorator('callString', {
              rules:[{ required: true, message: 'Required' },
{ max: 24, message: 'Exceeds max length of 24' },
],
              
              })
              ( <Input placeholder={"callString"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='callTypeId'>callTypeId</label>
              <br />             
              {getFieldDecorator('callTypeId', {
              rules:[],
              
              })
              ( <Input placeholder={"callTypeId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='dateCleared'>dateCleared</label>
              <br />             
              {getFieldDecorator('dateCleared', {
              rules:[],
              
              })
              ( <Input placeholder={"dateCleared"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='dateCreated'>dateCreated</label>
              <br />             
              {getFieldDecorator('dateCreated', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"dateCreated"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='dateDispatched'>dateDispatched</label>
              <br />             
              {getFieldDecorator('dateDispatched', {
              rules:[],
              
              })
              ( <Input placeholder={"dateDispatched"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='quickCallNumber'>quickCallNumber</label>
              <br />             
              {getFieldDecorator('quickCallNumber', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"quickCallNumber"} /> )}
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

export const WrappedCallEditComponent = Form.create({ name: 'Call Edit' })(CallEditComponent);

/*<Codenesium>
    <Hash>611e8d083c8c5fbf9b55e22939db16c0</Hash>
</Codenesium>*/