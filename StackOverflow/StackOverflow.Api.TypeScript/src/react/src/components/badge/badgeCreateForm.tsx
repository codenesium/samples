import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/apiObjects';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import BadgeMapper from './badgeMapper';
import BadgeViewModel from './badgeViewModel';
import { Form, Input, Button, Checkbox, InputNumber, DatePicker} from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface BadgeCreateComponentProps {
  form:WrappedFormUtils;
  history:any;
  match:any;
}

interface BadgeCreateComponentState {
  model?: BadgeViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
  submitted:boolean;
}

class BadgeCreateComponent extends React.Component<
  BadgeCreateComponentProps,
  BadgeCreateComponentState
> {
  state = {
    model: new BadgeViewModel(),
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
        let model = values as BadgeViewModel;
        console.log('Received values of form: ', model);
        this.submit(model);
      }
    });
  };

  submit = (model:BadgeViewModel) =>
  {  
    let mapper = new BadgeMapper();
     axios
      .post(
        Constants.ApiEndpoint + ApiRoutes.Badges,
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
            Api.BadgeClientRequestModel
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
      return <LoadingForm />;
    } 
    else if (this.state.loaded) {

        return ( 
         <Form onSubmit={this.handleSubmit}>
            			<Form.Item>
              <label htmlFor='date'>Date</label>
              <br />             
{getFieldDecorator('date', {
              rules:[],
              })
              ( <Input placeholder={"Date"} id={"date"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='name'>Name</label>
              <br />             
{getFieldDecorator('name', {
              rules:[],
              })
              ( <Input placeholder={"Name"} id={"name"} /> )}
              </Form.Item>

						<Form.Item>
              <label htmlFor='userId'>UserId</label>
              <br />             
{getFieldDecorator('userId', {
              rules:[],
              })
              ( <Input placeholder={"UserId"} id={"userId"} /> )}
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

export const WrappedBadgeCreateComponent = Form.create({ name: 'Badge Create' })(BadgeCreateComponent);

/*<Codenesium>
    <Hash>1e63a166eb2876b690127483688d56ed</Hash>
</Codenesium>*/