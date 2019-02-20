import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import RateMapper from './rateMapper';
import RateViewModel from './rateViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface RateDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface RateDetailComponentState {
  model?: RateViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class RateDetailComponent extends React.Component<
  RateDetailComponentProps,
  RateDetailComponentState
> {
  state = {
    model: new RateViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Rates + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Rates +
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
          let response = resp.data as Api.RateClientResponseModel;

          console.log(response);

          let mapper = new RateMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
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

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <div>amountPerMinute</div>
              <div>{this.state.model!.amountPerMinute}</div>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>teacherId</h3>
              <div>{this.state.model!.teacherIdNavigation!.toDisplay()}</div>
            </div>
            <div style={{ marginBottom: '10px' }}>
              <h3>teacherSkillId</h3>
              <div>
                {this.state.model!.teacherSkillIdNavigation!.toDisplay()}
              </div>
            </div>
          </div>
          {message}
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedRateDetailComponent = Form.create({ name: 'Rate Detail' })(
  RateDetailComponent
);


/*<Codenesium>
    <Hash>1bd65f1cbbbb9e54853f0a60ab7eaaf6</Hash>
</Codenesium>*/