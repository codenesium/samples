import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import HandlerPipelineStepMapper from './handlerPipelineStepMapper';
import HandlerPipelineStepViewModel from './handlerPipelineStepViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';

interface HandlerPipelineStepCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface HandlerPipelineStepCreateComponentState {
  model?: HandlerPipelineStepViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class HandlerPipelineStepCreateComponent extends React.Component<
  HandlerPipelineStepCreateComponentProps,
  HandlerPipelineStepCreateComponentState
> {
  state = {
    model: new HandlerPipelineStepViewModel(),
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
        let model = values as HandlerPipelineStepViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:HandlerPipelineStepViewModel) =>
  {  
    let mapper = new HandlerPipelineStepMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.HandlerPipelineSteps,
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
            Api.HandlerPipelineStepClientRequestModel
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
              <label htmlFor='handlerId'>handlerId</label>
              <br />             
              {getFieldDecorator('handlerId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"handlerId"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='pipelineStepId'>pipelineStepId</label>
              <br />             
              {getFieldDecorator('pipelineStepId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <DatePicker format={'YYYY-MM-DD'} placeholder={"pipelineStepId"} /> )}
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

export const WrappedHandlerPipelineStepCreateComponent = Form.create({ name: 'HandlerPipelineStep Create' })(HandlerPipelineStepCreateComponent);

/*<Codenesium>
    <Hash>6ff702f81c25e4c5ea359c4d1caed937</Hash>
</Codenesium>*/