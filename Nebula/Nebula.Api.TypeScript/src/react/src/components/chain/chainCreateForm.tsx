import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ChainMapper from './chainMapper';
import ChainViewModel from './chainViewModel';
import { Form, Input, Button, Switch, InputNumber, DatePicker, Spin, Alert, TimePicker } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { ChainStatusSelectComponent } from '../shared/chainStatusSelect'
	import { TeamSelectComponent } from '../shared/teamSelect'
	
interface ChainCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface ChainCreateComponentState {
  model?: ChainViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class ChainCreateComponent extends React.Component<
  ChainCreateComponentProps,
  ChainCreateComponentState
> {
  state = {
    model: new ChainViewModel(),
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
        let model = values as ChainViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:ChainViewModel) =>
  {  
    let mapper = new ChainMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Chains,
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
            Api.ChainClientRequestModel
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
              <label htmlFor='chainStatusId'>ChainStatusId</label>
              <br />             
              {getFieldDecorator('chainStatusId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"ChainStatusId"} /> )}
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
              <label htmlFor='name'>Name</label>
              <br />             
              {getFieldDecorator('name', {
              rules:[{ required: true, message: 'Required' },
{ max: 128, message: 'Exceeds max length of 128' },
],
              
              })
              ( <Input placeholder={"Name"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='teamId'>TeamId</label>
              <br />             
              {getFieldDecorator('teamId', {
              rules:[{ required: true, message: 'Required' },
],
              
              })
              ( <Input placeholder={"TeamId"} /> )}
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

export const WrappedChainCreateComponent = Form.create({ name: 'Chain Create' })(ChainCreateComponent);

/*<Codenesium>
    <Hash>659e2152d8dc28fe87610451feb31dc1</Hash>
</Codenesium>*/