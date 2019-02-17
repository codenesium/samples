import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/apiObjects';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm';
import { ErrorForm } from '../../lib/components/errorForm';
import PostLinkMapper from './postLinkMapper';
import PostLinkViewModel from './postLinkViewModel';

interface Props {
  history: any;
  model?: PostLinkViewModel;
}

const PostLinkDetailDisplay = (model: Props) => {
  return (
    <form role="form">
      <button
        className="btn btn-primary btn-sm align-middle float-right vertically-center"
        onClick={e => {
          model.history.push(
            ClientRoutes.PostLinks + '/edit/' + model.model!.id
          );
        }}
      >
        <i className="fas fa-edit" />
      </button>
      <div className="form-group row">
        <label htmlFor="creationDate" className={'col-sm-2 col-form-label'}>
          CreationDate
        </label>
        <div className="col-sm-12">{String(model.model!.creationDate)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="linkTypeId" className={'col-sm-2 col-form-label'}>
          LinkTypeId
        </label>
        <div className="col-sm-12">{String(model.model!.linkTypeId)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="postId" className={'col-sm-2 col-form-label'}>
          PostId
        </label>
        <div className="col-sm-12">{String(model.model!.postId)}</div>
      </div>
      <div className="form-group row">
        <label htmlFor="relatedPostId" className={'col-sm-2 col-form-label'}>
          RelatedPostId
        </label>
        <div className="col-sm-12">{String(model.model!.relatedPostId)}</div>
      </div>
    </form>
  );
};

interface IParams {
  id: number;
}

interface IMatch {
  params: IParams;
}

interface PostLinkDetailComponentProps {
  match: IMatch;
  history: any;
}

interface PostLinkDetailComponentState {
  model?: PostLinkViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

export default class PostLinkDetailComponent extends React.Component<
  PostLinkDetailComponentProps,
  PostLinkDetailComponentState
> {
  state = {
    model: undefined,
    loading: false,
    loaded: false,
    errorOccurred: false,
    errorMessage: '',
  };

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.PostLinks +
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
          let response = resp.data as Api.PostLinkClientResponseModel;

          let mapper = new PostLinkMapper();

          console.log(response);

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
    if (this.state.loading) {
      return <LoadingForm />;
    } else if (this.state.errorOccurred) {
      return <ErrorForm message={this.state.errorMessage} />;
    } else if (this.state.loaded) {
      return (
        <PostLinkDetailDisplay
          history={this.props.history}
          model={this.state.model}
        />
      );
    } else {
      return null;
    }
  }
}


/*<Codenesium>
    <Hash>fec6e51b865bfd1a24cb0f95307a137d</Hash>
</Codenesium>*/